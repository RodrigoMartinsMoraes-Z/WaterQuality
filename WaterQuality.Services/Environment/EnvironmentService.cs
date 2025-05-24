using System.Net;

using WaterQuality.Common.Response;
using WaterQuality.Domain.Environment;
using WaterQuality.Interfaces.Repository;
using WaterQuality.Interfaces.Services;

namespace WaterQuality.Services.Environment;

public class EnvironmentService(IEnvironmentalRepository repository)
: IEnvironmentService
{
    private readonly IEnvironmentalRepository _repository = repository;

    public async Task<DefaultResponse> GetAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _repository.GetAsync(cancellationToken).ConfigureAwait(true);
            return new DefaultResponse(result, HttpStatusCode.OK, "Dados ambientais recuperados com sucesso.");
        }
        catch (Exception ex)
        {
            return new DefaultResponse(null, HttpStatusCode.InternalServerError, $"Erro ao recuperar dados: {ex.Message}");
        }
    }

    public async Task<DefaultResponse> GetRealtimeAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _repository.GetAsync(DateTime.Now, cancellationToken).ConfigureAwait(true);
            return new DefaultResponse(result, HttpStatusCode.OK, "Dados em tempo real recuperados com sucesso.");
        }
        catch (Exception ex)
        {
            return new DefaultResponse(null, HttpStatusCode.InternalServerError, $"Erro ao recuperar dados em tempo real: {ex.Message}");
        }
    }

    public async Task<DefaultResponse> GetCurrentDayAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _repository.GetAsync(DateTime.Today, cancellationToken).ConfigureAwait(true);
            return new DefaultResponse(result, HttpStatusCode.OK, "Dados do dia atual recuperados com sucesso.");
        }
        catch (Exception ex)
        {
            return new DefaultResponse(null, HttpStatusCode.InternalServerError, $"Erro ao recuperar dados do dia: {ex.Message}");
        }
    }

    public async Task<DefaultResponse> GetFromDayAsync(DateTime date, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _repository.GetAsync(date, cancellationToken).ConfigureAwait(true);
            return new DefaultResponse(result, HttpStatusCode.OK, $"Dados do dia {date:dd/MM/yyyy} recuperados com sucesso.");
        }
        catch (Exception ex)
        {
            return new DefaultResponse(null, HttpStatusCode.InternalServerError, $"Erro ao recuperar dados da data especificada: {ex.Message}");
        }
    }

    public async Task<DefaultResponse> SaveAsync(EnvironmentalParameter parameter, CancellationToken cancellationToken = default)
    {
        try
        {
            await _repository.SaveAsync(parameter, cancellationToken).ConfigureAwait(true);
            return new DefaultResponse(null, HttpStatusCode.Created, "Dados ambientais salvos com sucesso.");
        }
        catch (Exception ex)
        {
            return new DefaultResponse(null, HttpStatusCode.InternalServerError, $"Erro ao salvar dados: {ex.Message}");
        }
    }
}
