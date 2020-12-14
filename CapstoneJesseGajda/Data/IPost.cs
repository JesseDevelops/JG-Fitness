using CapstoneJesseGajda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneJesseGajda.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);
        Task Add(Post post);
        Task Delete(int id);
        Task EditContent(int id, string newContent);
        IEnumerable<Post> GetLatestPosts(int n);

        Task AddReply(PostReply reply);
    }
}
