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

    public async Task<Guid> CreateShowing(CreateShowingDto showing)
    {
        var userToCreate = _mapper.Map<Domain.Entities.Showing>(showing);
        var createdUser = await _repository.CreateShowing(userToCreate);
        return await Task.FromResult(createdUser);
    }

    public async Task<List<GetShowingDto>> GetAllShowings()
    {
        var showings = _mapper.Map<List<GetShowingDto>>(await _repository.GetAllShowings());
        return await Task.FromResult(showings);
    }

    public async Task<GetShowingDto> GetShowingById(Guid id)
    {
        var showing = _mapper.Map<GetShowingDto>(await _repository.GetShowingById(id));
        return await Task.FromResult(showing);
    }

    public async Task<bool> UpdateShowingById(Guid id, CreateShowingDto showing)
    {
        var showingToUpdate = _mapper.Map<Domain.Entities.Showing>(showing);
        var isShowingUpdated = await _repository.UpdateShowingById(id, showingToUpdate);
        return await Task.FromResult(isShowingUpdated);
    }

    public Task<bool> DeleteShowingById(Guid id)
    {
        throw new NotImplementedException();
    }
}