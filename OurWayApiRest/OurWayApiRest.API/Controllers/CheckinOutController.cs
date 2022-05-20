using Microsoft.AspNetCore.Mvc;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using OurWayApiRest.DAL;
using System;
using System.Linq;

namespace OurWayApiRest.API.Controllers
{
    public class CheckinOutController : MainController
    {
        private readonly ICheckinOutRepository _repository;
        private readonly ITripRepository _tripRepository;
        private readonly IUserRepository _userRepository;
        public CheckinOutController(ICheckinOutRepository repository, INotificador notificador, ITripRepository tripRepository, IUserRepository userRepository) : base(notificador)
        {
            _repository = repository;
            _tripRepository = tripRepository;
            _userRepository = userRepository;
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(CheckinOut model)
        {
            try
            {
                var result = _repository.Update(model).Result;
                //
                if (result == null)
                {
                    NotificarErro("CheckinOut não encontrado!");
                    return CustomResponse();
                }
                return CustomResponse(result);
            }
            catch (Exception)
            {
                NotificarErro("problema encontrado!");
                return CustomResponse();
            }

        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(CheckinOut model)
        {
            try
            {
                var result = _repository.Insert(model).Result;
                //
                if (result == null)
                {
                    NotificarErro("CheckinOut não encontrado!");
                    return CustomResponse();
                }
                return CustomResponse(result);
            }
            catch (Exception)
            {
                NotificarErro("problema encontrado!");
                return CustomResponse();
            }
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var result = await _repository.GetById(new CheckinOut() { CIdCheckinOut = id });
                if (result == null)
                {
                    NotificarErro("CheckinOut não encontrado!");
                    return CustomResponse();
                }
                return CustomResponse(result);
            }
            catch (Exception)
            {
                NotificarErro("problema encontrado!");
                return CustomResponse();
            }
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _repository.GetAll();
                if (result == null)
                {
                    NotificarErro("Checkin não encontrado!");
                    return CustomResponse();
                }
                return CustomResponse(result);
            }
            catch (Exception)
            {
                NotificarErro("problema encontrado!");
                return CustomResponse();
            }
        }
        [HttpGet]
        [Route("GetTripCard")]
        public async Task<IActionResult> GetTripCard()
        {
            try
            {
                var tripCards = new List<TripCard>();
                var result = await _repository.GetTripCard();
                if (result == null)
                {
                    NotificarErro("Checkin não encontrado!");
                    return CustomResponse();
                }
                //
                foreach (var i in result)
                {
                    var model = new TripCard();
                    //
                    model.trip = await _tripRepository.GetById(new Trip() { CIdTrip = i.CIdTrip });
                    //
                    model.UserCreated = await _userRepository.GetById(new User() { cIdUser = i.CIdUser });
                    //
                    model.origin = new PosAdress() { longitude = Convert.ToDouble(i.YCoordIn), latitude = Convert.ToDouble(i.XCoordIn)};

                    model.destination = new PosAdress() { longitude = Convert.ToDouble(i.YCoordOut), latitude = Convert.ToDouble(i.XCoordOut) };
                    //
                    model.quantityTrip = result.Count();
                    //
                    tripCards.Add(model);
                }
                //
                return CustomResponse(tripCards);
            }
            catch (Exception)
            {
                NotificarErro("problema encontrado!");
                return CustomResponse();
            }
        }
    }
}
