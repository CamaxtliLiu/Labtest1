using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using LabTest1.Service;
using Labtest1.Model;
namespace Labtest1.Viewmodel;

public class PostsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PostRecord> _posts;
        private ApiClient _apiClient;

        public ObservableCollection<PostRecord> Posts
        {
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }
    private string _title; // Define Title property
    private string _body; // Define Body property

  

    // Define Title property
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    // Define Body property
    public string Body
    {
        get => _body;
        set
        {
            _body = value;
            OnPropertyChanged();
        }
    }
    public PostsViewModel()
        {
            _apiClient = new ApiClient(); // Initialize your API client

            // Load posts when the ViewModel is created
            LoadPosts();
        }

        private async void LoadPosts()
        {
            var posts = await _apiClient.GetPostsAsync();
            Posts = new ObservableCollection<PostRecord>();
        }

        public async Task<bool> AddPostAsync(string title, string body)
        {
            // Make the API call to add the post
            var result = await _apiClient.AddPostAsync(title, body);

            // Check if the API call was successful
            if (!string.IsNullOrEmpty(result))
            {
                // Reload the posts after adding a new one
                LoadPosts();
                return true;
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
