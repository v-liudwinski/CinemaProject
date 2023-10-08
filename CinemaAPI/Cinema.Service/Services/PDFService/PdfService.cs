using AutoMapper;
using ceTe.DynamicPDF.HtmlConverter;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class PdfService : IPdfService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public PdfService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _loggerManager = loggerManager;
    }

    public async Task<byte[]> GetTicket(int id)
    {
        var ticket = await _repository.Ticket.GetTicketAsync(id);
        if (ticket is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Ticket), id));
        }

        Random rand = new();
        string[] colors =
        {
            "success",
            "primary",
            "warning",
            "danger"
        };

        string tempHtml = $@"<!DOCTYPE html> <html lang='en'><head><meta charset='UTF-8'>
            <meta http-equiv='X-UA-Compatible' content='IE=edge'>      
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
             <title>Ticket</title><link rel='stylesheet' 
                href='https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css' 
                integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'>
                <style> body {{ font-size: x-large; }} </style> </head><body>
                <div class='container m-5'> <div class='row'> <div class='col-4'></div>
                <div class='card col-6 bg-{colors[rand.Next(0, 4)]}' style='width: 18rem;'>
                <div class='card-header'><h3 class='text-bg-success'>Квиток: { ticket.Id }</h3> 
                </div><div class='card-body'><p> Ціна квитка: { ticket.Price }₴ </p>
                <p> Сеанс: { ticket.Seanse.Id } </p> <p> Зал: { ticket.Seanse.HallId } </p>
                <p> Дата початку: { ticket.Seanse.StartTime }</p>
                <p> Назва фільму: { ticket.Seanse.Movie.Title}</p>
                <p> Назва фільму в оригіналі: { ticket.Seanse.Movie.OriginalTitle}</p>
                <p> Тривалість: { ticket.Seanse.Movie.Duration}</p>
                </div><div class='card-footer'><p> Місце: Ряд { ticket.Seat.Row}</p>
                <p> Номер { ticket.Seat.SeatNumber }</p><p> Тип місця { ticket.Seat.SeatType.Type}</p>
                </div></div></div></div></body></html>";

        return Converter.Convert(tempHtml);
    }
}
