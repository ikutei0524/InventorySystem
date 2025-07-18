namespace InventorySystem.models;
//完整物件如下

public class OperationResult<T>
{
    //屬性
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    
    //建構子
    //成功建構子
    private OperationResult(string message, T data)
    {
        Success = true;
        Message = message;
        Data = data;
    }
    //失敗建構子
    private OperationResult(string errorMessage)
    {
        Success = false;
        Message = errorMessage;
        Data = default(T); //null
    }

    //方法
    public static OperationResult<T> SuccessResult(string message,T data)
    {
        return new OperationResult<T>(message, data);
    }

    public static OperationResult<T> ErrorResult(string message)
    {
        return new OperationResult<T>(message,default(T));
    }
}
