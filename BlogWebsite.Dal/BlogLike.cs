//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogWebsite.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlogLike
    {
        public int BlogLikeId { get; set; }
        public int BlogId { get; set; }
        public string UserId { get; set; }
        public System.DateTime LikedOn { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Blog Blog { get; set; }
    }
}