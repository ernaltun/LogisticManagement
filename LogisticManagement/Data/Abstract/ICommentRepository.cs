﻿using LogisticManagement.Entity;

namespace LogisticManagement.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
        void CreateComment(Comment comment);
    }
}
