using AutoMapper;
using FluentValidation;
using ProjektNTP.Application.Showing.Dtos;
using ProjektNTP.Domain.Abstractions;

namespace ProjektNTP.Application.Services;

public class ShowingService : IShowingService
{
    private readonly IShowingRepository _repository;
    private readonly IMapper _mapper;

    public ShowingService(IShowingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateShowing(CreateShowingDto newShowing)
    {
        var newShowingDto = _mapper.Map<Domain.Entities.Showing>(newShowing);
        var createdShowing = await _repository.CreateShowing(newShowingDto);
        return await Task.FromResult(createdShowing);
    }

    public async Task<List<GetShowingDto>> GetAllShowings()
    {
        var showings = await _repository.GetAllShowings();
        var showingsDto = _mapper.Map<List<GetShowingDto>>(showings);
        return await Task.FromResult(showingsDto);
    }

    public async Task<GetShowingDto> GetShowingById(Guid id)
    {
        var showing = await _repository.GetShowingById(id);
        var showingDto = _mapper.Map<GetShowingDto>(showing);
        return await Task.FromResult(showingDto);
    }

    public async Task<bool> UpdateShowingById(Guid id, CreateShowingDto newShowing)
    {
        var newShowingDto = _mapper.Map<Domain.Entities.Showing>(newShowing);
        var isShowingUpdated = await _repository.UpdateShowingById(id, newShowingDto);
        return await Task.FromResult(isShowingUpdated);
    }

    public async Task<bool> DeleteShowingById(Guid id)
    {
        var isShowingDeleted = await _repository.DeleteShowingById(id);
        return await Task.FromResult(isShowingDeleted);
    }
}