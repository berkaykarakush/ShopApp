﻿namespace EntityLayer
{
    public class Order
    {
        public Order()
        {
            OrderId = new Random().Next(111111111, 999999999);
        }
        public double OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public string? PaymentId { get; set; }
        public string? ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumOrderState OrderState { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }

    public enum EnumOrderState
    {
        waiting = 0,
        shipped = 1,
        completed = 2,
    }
    public enum EnumPaymentType
    {
       CreditCart = 0,
       EFT = 1
    }
}
