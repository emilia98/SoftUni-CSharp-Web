﻿namespace ForumSystem.Web.ViewModels.Home
{
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>

        // , IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";

        /*
        public string Url { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, IndexCategoryViewModel>()
                .ForMember(
                    x => x.Url,
                    c => c.MapFrom(e => "/f/"  + e.Id.ToString() + "/" + e.Name.Replace(' ', '-')));
        }
        */
    }
}
