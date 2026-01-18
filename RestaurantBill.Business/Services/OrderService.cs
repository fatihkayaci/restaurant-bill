using RestaurantBill.Core;
using RestaurantBill.Core.Interfaces;
using RestaurantBill.Core.DTOs;
using AutoMapper;

namespace RestaurantBill.Business.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IGenericRepository<OrderItem> _orderItemRepository;
    private readonly IMapper _mapper;
    public OrderService(
        IOrderRepository orderRepository,
        IGenericRepository<OrderItem> orderItemRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }
    public async  Task AddAsync(CreateOrderDto dto)
    {
        var order = _mapper.Map<Order>(dto);
        await _orderRepository.AddAsync(order);
    }

    public async Task DeleteOrderDetailAsync(int id)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(id);
        if (orderItem == null) throw new Exception("Silinecek ürün bulunamadı.");

        var order = await _orderRepository.GetByIdAsync(orderItem.OrderId);
        if (order == null) throw new Exception("Bağlı olduğu sipariş bulunamadı.");

        order.TotalPrice -= orderItem.Price;
        if (order.TotalPrice < 0) order.TotalPrice = 0;
        await _orderRepository.UpdateAsync(order);
        await _orderItemRepository.DeleteAsync(id);
    }

    public async Task<List<OrderResponse>> GetAllAsync()
    {
        var entities = await _orderRepository.GetAllAsync();
        return _mapper.Map<List<OrderResponse>>(entities);
    }
    public async Task<OrderResponse> GetOrderDetailsAsync(int id)
    {
        var order = await _orderRepository.GetOrderWithDetailsAsync(id);
        if (order == null) throw new Exception("Sipariş bulunamadı");
        return _mapper.Map<OrderResponse>(order);
    }
}