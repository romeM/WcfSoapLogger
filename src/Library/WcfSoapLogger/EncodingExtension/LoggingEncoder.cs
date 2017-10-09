﻿using System;
using System.IO;
using System.ServiceModel.Channels;
using System.Threading;

namespace WcfSoapLogger.EncodingExtension
{
    public class LoggingEncoder : MessageEncoder
    {
        private readonly LoggingEncoderFactory _factory;
        private readonly string _contentType;
        private readonly MessageEncoder _innerEncoder;
        private readonly SoapLoggerSettings _settings;

        public override string ContentType {
            get {
                return _contentType;
            }
        }

        public override string MediaType {
            get {
                return _factory.MediaType;
            }
        }

        public override MessageVersion MessageVersion {
            get {
                return _factory.MessageVersion;
            }
        }


        public LoggingEncoder(LoggingEncoderFactory factory) {
            _factory = factory;
            _innerEncoder = _factory.InnerMessageFactory.Encoder;
            _contentType = _factory.MediaType;
            _settings = _factory.Settings;
        }

        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType) {
            byte[] body = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, body, 0, body.Length);
            ProcessMessage(body, false);

            return _innerEncoder.ReadMessage(buffer, bufferManager, contentType);
        }

        public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType) {
            return _innerEncoder.ReadMessage(stream, maxSizeOfHeaders, contentType);
        }



        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset) {
            ArraySegment<byte> arraySegment = _innerEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);

            var body = new byte[arraySegment.Count];
            Array.Copy(arraySegment.Array, arraySegment.Offset, body, 0, body.Length);
            ProcessMessage(body, true);

            return arraySegment;
        }

        public override void WriteMessage(Message message, Stream stream) {
            _innerEncoder.WriteMessage(message, stream);
        }


        private void ProcessMessage(byte[] body, bool writeMessage)
        {
            //XOR, because response is writeMessage on web-service and readMessage on client
            bool response = writeMessage ^ _settings.IsClient;
            SoapLoggerHandler.ProcessBody(body, response, _settings);
        }


    }
}
