using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeighbor.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string? Error { get; }

        protected Result(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;

            if (isSuccess && error != null) throw new InvalidOperationException("Success result cannot have error");
            if (!isSuccess && error == null) throw new InvalidOperationException("Failure must have error");
        }

        public static Result Success() => new Result(true, null);

        public static Result Failure(string error) => new Result(false, error);
    }
}
