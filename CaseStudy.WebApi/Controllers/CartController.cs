using AutoMapper;
using CaseStudy.API.Controllers;
using CaseStudy.Core;
using CaseStudy.Core.DTOs;
using CaseStudy.Core.Services;
using CaseStudy.Service.Services;
using CaseStudy.WebApi.HelperMethods;
using CaseStudy.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaseStudy.WebApi.Controllers
{
    public class CartController : CustomBaseController
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;
        public CartController(ICartService cartService, ICartItemService cartItemService, IMapper mapper)
        {
            _cartService = cartService;
            _cartItemService = cartItemService; 
            _mapper = mapper;  
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Summary()
        {
            var result = await _cartService.GetCartsWitCartsItems();           
            return CreateActionResult(CustomResponseDto<List<CartWithCartItemsDto>>.Success(HttpStatusCode.OK, result));
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteCartItem(int id)
        {
            _cartItemService.Remove(id);
            return CreateActionResult(CustomResponseDto<string>.Success(HttpStatusCode.OK, "Cart item removed."));
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateItemQuantity(CartItemUpdateDto cartItemUpdateDto)
        {
            var updatedCartItem = await _cartItemService.GetByIdAsync(cartItemUpdateDto.Id);
            if (updatedCartItem != null)
            {
                updatedCartItem.Quantity = cartItemUpdateDto.Quantity;
                var cartItem = _mapper.Map<CartItemUpdateDto>(_cartItemService.Update(updatedCartItem));
                return CreateActionResult(CustomResponseDto<CartItemUpdateDto>.Success(HttpStatusCode.OK, cartItem));
            }
            return CreateActionResult(CustomResponseDto<CartItemDto>.Fail(HttpStatusCode.BadRequest, "Cart item does not exists"));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            var cart = await _cartService.AddAsync(new Cart { Token = TokenGenerator.Generate()});
            var addedCartDto = _mapper.Map<CartDto>(cart);
            return CreateActionResult(CustomResponseDto<CartDto>.Success(HttpStatusCode.OK, addedCartDto));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddItem(CartItemAddDto cartItemAddDto)
        {
            var currentCart = await _cartService.GetCartByToken(cartItemAddDto.Token);
            if (currentCart != null)
            {
                cartItemAddDto.CartId = currentCart.Id;
                var test = _mapper.Map<CartItem>(cartItemAddDto);
                var cart = await _cartItemService.AddAsync(test);
                var addedCartDto = _mapper.Map<CartItemDto>(cart);
                return CreateActionResult(CustomResponseDto<CartItemDto>.Success(HttpStatusCode.OK, addedCartDto));
            }
            return CreateActionResult(CustomResponseDto<CartItemDto>.Fail(HttpStatusCode.BadRequest, "Cart does not exists!"));
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult IsInDeliveryArea(LocationRequestModel locationRequestModel)
        {
            var result = IsCustomerInDeliveryArea(locationRequestModel.locations, locationRequestModel.customerLocation);
            return CreateActionResult(CustomResponseDto<bool>.Success(HttpStatusCode.OK, result));
        }

        [NonAction]
        public bool IsCustomerInDeliveryArea(List<Location> locations, Location customerLocation)
        {
            double minX = locations[0].Latitude;
            double maxX = locations[0].Latitude;
            double minY = locations[0].Longitude;
            double maxY = locations[0].Longitude;
            for (int i = 1; i < locations.Count; i++)
            {
                Location q = locations[i];
                minX = Math.Min(q.Latitude, minX);
                maxX = Math.Max(q.Latitude, maxX);
                minY = Math.Min(q.Longitude, minY);
                maxY = Math.Max(q.Longitude, maxY);
            }
            if (customerLocation.Latitude < minX || customerLocation.Latitude > maxX || customerLocation.Longitude < minY || customerLocation.Longitude > maxY)
            {
                return false;
            }           
            bool inside = false;
            for (int i = 0, j = locations.Count - 1; i < locations.Count; j = i++)
            {
                if ((locations[i].Longitude > customerLocation.Longitude) != (locations[j].Longitude > customerLocation.Longitude) &&
                     customerLocation.Latitude < (locations[j].Latitude - locations[i].Latitude) * (customerLocation.Longitude - locations[i].Longitude) / (locations[j].Longitude - locations[i].Longitude) + locations[i].Latitude)
                {
                    inside = !inside;
                }
            }
            return inside;
        }
    }
}