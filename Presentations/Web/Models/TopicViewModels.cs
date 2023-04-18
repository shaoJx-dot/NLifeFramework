using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class TopicViewModel
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        [DisplayName("内容")]
        public string Body { get; set; }
        [DisplayName("描述")]
        public string Description { get; set; }
        [DisplayName("评论数")]
        public long ReplyCount { get; set; }
        [DisplayName("发表时间")]
        public DateTime CreateTime { get; set; }
    }
    
}