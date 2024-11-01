class ServerResult{

    public bool Success {get; set; }
    public string Message {get; set; }
    public object Data {get; set; }
    public ServerResult(bool success, string message, object data){
        Success = success;
        Message = message;
        Data = data;
    }

    public ServerResult(bool success, string message){
        Success = success;
        Message = message;
    }

    public ServerResult(bool success){
        Success = success;
    }

    public ServerResult(){
        Success = true;
    }

}