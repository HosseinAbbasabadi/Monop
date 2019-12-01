using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Framework.Core
{
    public class OperationResult
    {
        public string TableName { get; set; }
        public string Operation { get; set; }
        private long RecordId { get; set; }
        private string Message { get; set; }
        private bool Success { get; set; }
        private List<KeyValuePair<string, object>> Data { get; set; }
        private DateTime OperationDate { get; set; }

        public OperationResult()
        {
        }

        public OperationResult(string tableName, string operation)
        {
            TableName = tableName;
            Operation = operation;
            Success = false;
            OperationDate = DateTime.Now;
        }

        public OperationResult FeedResult(long recordId, List<KeyValuePair<string, object>> data)
        {
            RecordId = recordId;
            Data = data;
            return this;
        }

        public OperationResult Failed(string failureMessage)
        {
            Message = failureMessage;
            return this;
        }

        public OperationResult Succeeded(string successMessage)
        {
            Message = successMessage;
            Success = true;
            return this;
        }

        public bool IsSuccessful()
        {
            return Success;
        }

        public string GetMessage()
        {
            return Message;
        }

        public List<KeyValuePair<string, object>> GetData()
        {
            return Data;
        }

        public long GetRecordId()
        {
            return RecordId;
        }
    }
}