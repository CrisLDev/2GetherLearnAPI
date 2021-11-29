using _2GetherLearnAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace _2GetherLearnAPI.Services
{
    public class PostService
    {
        private readonly IMongoCollection<Post> _posts;
        public  PostService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _posts = database.GetCollection<Post>("posts");
        }
        public async Task<IList<Post>> GetPostsAsync()
        {
            return await _posts.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
        public async Task<Post> GetPostAsync(string id)
        {
            return await _posts.FindAsync(post => post.Id == id).Result.FirstOrDefaultAsync();
        }
        public async Task<Post> CreatePostAsync(Post post)
        {
            await _posts.InsertOneAsync(post);
            return post;
        }
        public async Task<Post> UpdatePostAsync(string id, Post postIn)
        {
            await _posts.ReplaceOneAsync(post => post.Id == id, postIn);
            return postIn;
        }
        public async Task RemovePostAsync(string id)
        {
            await _posts.DeleteOneAsync(post => post.Id == id);
        }
    }
}
