using System;
using System.Collections.Generic;

namespace clubmembership.Models.DBObjects
{
    public partial class CodeSnippet
    {
        public CodeSnippet()
        {
            InverseIdSnippetPreviousVersionNavigation = new HashSet<CodeSnippet>();
        }

        public Guid IdCodeSnippet { get; set; }
        public string Title { get; set; } = null!;
        public string ContentCode { get; set; } = null!;
        public Guid IdMember { get; set; }
        public int Revision { get; set; }
        public Guid? IdSnippetPreviousVersion { get; set; }
        public DateTime DateTimeAdded { get; set; }

        public virtual Member IdMemberNavigation { get; set; } = null!;
        public virtual CodeSnippet? IdSnippetPreviousVersionNavigation { get; set; }
        public virtual ICollection<CodeSnippet> InverseIdSnippetPreviousVersionNavigation { get; set; }
    }
}
