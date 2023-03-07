using System;

namespace Shopping.DomainModel.BaseModel
{
  public  class OperationResult
  {
      public bool Success { get; private set; }
      public string Message { get; private set; }
      public string Operation { get; private set; }
      public DateTime OperationDate { get; private set; }
      public int? RecordID { get; set; }
      public string TableName { get; set; }

      public OperationResult(string Operation,string TableName)
      {
            Success = false;
            OperationDate=DateTime.Now;
            this.Operation = Operation;
            this.TableName = TableName;


      }
      public OperationResult(string Operation, string TableName,int RecordID)
      {
          Success = false;
          OperationDate = DateTime.Now;
          this.Operation = Operation;
          this.TableName = TableName;
            this.RecordID = RecordID;

        }

      public OperationResult ToSuccess(int? RecordID,string Message)
      {
            this.RecordID = RecordID;
            this.Message = Message;
            this.Success = true;
            return this;
      }
      public OperationResult ToSuccess( string Message)
      {
          
          this.Message = Message;
          this.Success = true;
          return this;
      }
        public OperationResult ToFail(int? RecordID, string Message)
      {
          this.RecordID = RecordID;
          this.Message = Message;
          this.Success = false;
          return this;
      }
        public OperationResult ToFail( string Message)
        {
           
            this.Message = Message;
            this.Success = false;
            return this;
        }
    }
}
