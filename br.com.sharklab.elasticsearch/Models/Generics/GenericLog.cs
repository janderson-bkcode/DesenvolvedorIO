﻿#nullable enable
using System;
using br.com.sharklab.elasticsearch.Models.LogTemplates;
using Serilog;

namespace br.com.sharklab.elasticsearch.Models.Generics
{
    public class GenericLog<T>
    {
        public T Data { get; set; }
        public Guid GuidIndex { get; set; }
        public DateTime TimeStamp { get; set; }
        public Exception? Exception { get; set; }
        public string IndexName { get; set; }

        public GenericLog(T data)
        {
            Data = data;
            TimeStamp = DateTime.Now;
        }
    }
}