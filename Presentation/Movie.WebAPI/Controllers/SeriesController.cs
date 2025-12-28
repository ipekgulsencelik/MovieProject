using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Features.CQRS.Handlers.SeriesHandlers;
using Movie.Application.Features.CQRS.Queries.SeriesQueries;
using Movie.DTO.DTOs.SeriesDTOs;

namespace Movie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly CreateSeriesCommandHandler _createSeriesCommandHandler;
        private readonly UpdateSeriesCommandHandler _updateSeriesCommandHandler;

        private readonly GetSeriesQueryHandler _getSeriesQueryHandler;
        private readonly GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
        private readonly GetSeriesByCategoryQueryHandler _getSeriesByCategoryQueryHandler;

        private readonly GetPendingSeriesQueryHandler _getPendingSeriesQueryHandler;
        private readonly GetPublishedSeriesQueryHandler _getPublishedSeriesQueryHandler;
        private readonly GetArchivedSeriesQueryHandler _getArchivedSeriesQueryHandler;
        private readonly GetDeletedSeriesQueryHandler _getDeletedSeriesQueryHandler;

        private readonly SearchSeriesQueryHandler _searchSeriesQueryHandler;

        private readonly ApproveSeriesCommandHandler _approveSeriesCommandHandler;
        private readonly RejectSeriesCommandHandler _rejectSeriesCommandHandler;

        private readonly UpdateSeriesStatusCommandHandler _updateSeriesStatusCommandHandler;

        private readonly ToggleSeriesVisibilityCommandHandler _toggleSeriesVisibilityCommandHandler;

        private readonly ArchiveSeriesCommandHandler _archiveSeriesCommandHandler;
        private readonly UnarchiveSeriesCommandHandler _unarchiveSeriesCommandHandler;

        private readonly SoftDeleteSeriesCommandHandler _softDeleteSeriesCommandHandler;
        private readonly HardDeleteSeriesCommandHandler _hardDeleteSeriesCommandHandler;
        private readonly RestoreSeriesCommandHandler _restoreSeriesCommandHandler;

        public SeriesController(CreateSeriesCommandHandler createSeriesCommandHandler, UpdateSeriesCommandHandler updateSeriesCommandHandler, GetSeriesQueryHandler getSeriesQueryHandler, GetSeriesByIdQueryHandler getSeriesByIdQueryHandler,  GetSeriesByCategoryQueryHandler getSeriesByCategoryQueryHandler, GetPendingSeriesQueryHandler getPendingSeriesQueryHandler, GetPublishedSeriesQueryHandler getPublishedSeriesQueryHandler, GetArchivedSeriesQueryHandler getArchivedSeriesQueryHandler, GetDeletedSeriesQueryHandler getDeletedSeriesQueryHandler, SearchSeriesQueryHandler searchSeriesQueryHandler, ApproveSeriesCommandHandler approveSeriesCommandHandler, RejectSeriesCommandHandler rejectSeriesCommandHandler, UpdateSeriesStatusCommandHandler updateSeriesStatusCommandHandler, ToggleSeriesVisibilityCommandHandler toggleSeriesVisibilityCommandHandler, ArchiveSeriesCommandHandler archiveSeriesCommandHandler, UnarchiveSeriesCommandHandler unarchiveSeriesCommandHandler, SoftDeleteSeriesCommandHandler softDeleteSeriesCommandHandler, HardDeleteSeriesCommandHandler hardDeleteSeriesCommandHandler, RestoreSeriesCommandHandler restoreSeriesCommandHandler)
        {
            _createSeriesCommandHandler = createSeriesCommandHandler;
            _updateSeriesCommandHandler = updateSeriesCommandHandler;

            _getSeriesQueryHandler = getSeriesQueryHandler;
            _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
            _getSeriesByCategoryQueryHandler = getSeriesByCategoryQueryHandler;

            _getPendingSeriesQueryHandler = getPendingSeriesQueryHandler;
            _getPublishedSeriesQueryHandler = getPublishedSeriesQueryHandler;
            _getArchivedSeriesQueryHandler = getArchivedSeriesQueryHandler;
            _getDeletedSeriesQueryHandler = getDeletedSeriesQueryHandler;

            _searchSeriesQueryHandler = searchSeriesQueryHandler;

            _approveSeriesCommandHandler = approveSeriesCommandHandler;
            _rejectSeriesCommandHandler = rejectSeriesCommandHandler;

            _updateSeriesStatusCommandHandler = updateSeriesStatusCommandHandler;

            _toggleSeriesVisibilityCommandHandler = toggleSeriesVisibilityCommandHandler;

            _archiveSeriesCommandHandler = archiveSeriesCommandHandler;
            _unarchiveSeriesCommandHandler = unarchiveSeriesCommandHandler;

            _softDeleteSeriesCommandHandler = softDeleteSeriesCommandHandler;
            _hardDeleteSeriesCommandHandler = hardDeleteSeriesCommandHandler;
            _restoreSeriesCommandHandler = restoreSeriesCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeriesList()
        {
            var list = await _getSeriesQueryHandler.Handle();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _getSeriesByIdQueryHandler.Handle(new GetSeriesByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("by-category/{categoryId:int}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var list = await _getSeriesByCategoryQueryHandler.Handle(new GetSeriesByCategoryQuery(categoryId));
            return Ok(list);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            var list = await _getPendingSeriesQueryHandler.Handle();
            return Ok(list);
        }

        [HttpGet("published")]
        public async Task<IActionResult> GetPublished()
        {
            var list = await _getPublishedSeriesQueryHandler.Handle();
            return Ok(list);
        }

        [HttpGet("archived")]
        public async Task<IActionResult> GetArchived()
        {
            var list = await _getArchivedSeriesQueryHandler.Handle();
            return Ok(list);
        }

        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeleted()
        {
            var list = await _getDeletedSeriesQueryHandler.Handle();
            return Ok(list);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchSeriesQuery query)
        {
            if (query == null || string.IsNullOrWhiteSpace(query.Q))
                return BadRequest("Arama parametresi (q) boş olamaz.");

            var list = await _searchSeriesQueryHandler.Handle(query);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSeriesCommand command)
        {
            await _createSeriesCommandHandler.Handle(command);
            return Ok("Dizi bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSeriesCommand command)
        {
            await _updateSeriesCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarılı!");
        }

        [HttpPatch("approve/{id:int}")]
        public async Task<IActionResult> Approve(int id)
        {
            await _approveSeriesCommandHandler.Handle(new ApproveSeriesCommand(id));
            return Ok("Dizi onaylandı.");
        }

        [HttpPatch("reject/{id:int}")]
        public async Task<IActionResult> Reject(int id)
        {
            await _rejectSeriesCommandHandler.Handle(new RejectSeriesCommand(id));
            return Ok("Dizi reddedildi.");
        }

        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateSeriesStatusDTO dto)
        {
            if (dto == null)
                return BadRequest("Geçersiz istek.");
            if (dto.Id <= 0)
                return BadRequest("Geçersiz dizi id.");

            await _updateSeriesStatusCommandHandler.Handle(
                new UpdateSeriesStatusCommand(dto.Id, dto.SeriesStatus)
            );

            return Ok("Dizi durumu güncellendi.");
        }

        [HttpPatch("toggle-visibility/{id:int}")]
        public async Task<IActionResult> ToggleVisibility(int id)
        {
            await _toggleSeriesVisibilityCommandHandler.Handle(new ToggleSeriesVisibilityCommand(id));
            return Ok("Dizi görünürlük durumu güncellendi.");
        }

        [HttpPatch("archive/{id:int}")]
        public async Task<IActionResult> Archive(int id)
        {
            await _archiveSeriesCommandHandler.Handle(new ArchiveSeriesCommand(id));
            return Ok("Dizi arşivlendi.");
        }

        [HttpPatch("unarchive/{id:int}")]
        public async Task<IActionResult> Unarchive(int id)
        {
            await _unarchiveSeriesCommandHandler.Handle(new UnarchiveSeriesCommand(id));
            return Ok("Dizi arşivden çıkarıldı.");
        }

        [HttpDelete("soft/{id:int}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _softDeleteSeriesCommandHandler.Handle(new SoftDeleteSeriesCommand(id));
            return Ok("Dizi çöp kutusuna taşındı (soft delete).");
        }

        [HttpDelete("hard/{id:int}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            await _hardDeleteSeriesCommandHandler.Handle(new HardDeleteSeriesCommand(id));
            return Ok("Dizi kalıcı olarak silindi.");
        }

        [HttpPatch("restore/{id:int}")]
        public async Task<IActionResult> Restore(int id)
        {
            await _restoreSeriesCommandHandler.Handle(new RestoreSeriesCommand(id));
            return Ok("Dizi geri yüklendi.");
        }
    }
}