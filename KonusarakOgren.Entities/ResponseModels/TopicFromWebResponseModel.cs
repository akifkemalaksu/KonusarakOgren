using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class TopicFromWebResponseModel : IResponseModel
    {
        public string UrlPath { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}