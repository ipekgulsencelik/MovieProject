using System;
using AutoMapper;
using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Helpers;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
                throw new ArgumentException("Kategori adı boş olamaz.");

            var category = _mapper.Map<Category>(command);

            // ✅ İş kuralı: yeni kategori her zaman Pending
            category.CategoryStatus = CategoryStatus.Pending;

            // ✅ BaseEntity uyumu
            category.IsActive = false;
            category.IsVisible = false;
            category.DataStatus = DataStatus.Created;
            category.CreatedDate = DateTime.UtcNow;
            category.ModifiedDate = null;
            category.DeletedDate = null;

            // ✅ Slug HER ZAMAN Name'den üretilir
            var baseSlug = SlugHelper.ToSlug(command.Name);
            category.Slug = await BuildUniqueSlugAsync(baseSlug);

            await _repository.CreateAsync(category);
        }

        private async Task<string> BuildUniqueSlugAsync(string baseSlug)
        {
            if (string.IsNullOrWhiteSpace(baseSlug))
                baseSlug = Guid.NewGuid().ToString("N");

            var slug = baseSlug;
            var i = 2;

            // ✅ Deleted dahil çakışmayı engelle
            while (await _repository.AnyAsync(x => x.Slug == slug, includeDeleted: true))
                slug = $"{baseSlug}-{i++}";

            return slug;
        }
    }
}