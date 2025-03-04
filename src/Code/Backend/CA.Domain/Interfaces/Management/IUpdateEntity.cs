﻿using System;

namespace CA.Domain.Interfaces.Management
{
    public interface IUpdateEntity<TKey> : IAddEntity<TKey>
    {
        public DateTime? UpdateDate { get; set; }
        public int? AccountIdUpdateDate { get; set; }
    }
}
