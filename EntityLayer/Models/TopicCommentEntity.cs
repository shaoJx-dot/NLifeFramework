﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class TopicCommentEntity : TopicComment
    {
        public Users UsersEntity { get; set; }

    }
}
