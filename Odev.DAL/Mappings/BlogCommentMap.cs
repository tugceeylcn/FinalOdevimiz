using Odev.DAL.Models;

namespace Odev.DAL.Mappings
{
    public class BlogCommentMap : BaseMap<BlogComment>
    {
        public BlogCommentMap()
        {
            ToTable("tblBlogComment");
        }
    }
}
