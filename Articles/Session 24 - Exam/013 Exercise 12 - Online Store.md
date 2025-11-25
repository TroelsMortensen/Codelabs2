# Exercise 12 - Online Store System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class OnlineStore {
        - storeName : String
        + addProduct(product : Product) void
        + createOrder(customer : Customer) ShoppingCart
        + getProductsByCategory(category : String) ArrayList~Product~
    }
    
    class Customer {
        - customerId : int
        - name : String
        - email : String
        - shippingAddress : String
        + Customer(customerId : int, name : String, email : String, shippingAddress : String)
        + getCustomerId() int
        + getName() String
        + getShippingAddress() String
    }
    
    class _Product_ {
        - productId : int
        - name : String
        # basePrice : double
        - category : String
        - stockQuantity : int
        + getPrice()* double
        + isInStock() boolean
    }
    
    class ShoppingCart {
        - cartId : int
        - orderDate : LocalDateTime
        + ShoppingCart(cartId : int)
        + addProduct(product : Product, quantity : int) void
        + removeProduct(productId : int) void
        + calculateTotal() double
    }
    
    class DigitalProduct {
        - downloadLink : String
        - fileSize : double
        + getPrice() double
    }
    
    class PhysicalProduct {
        - weight : double
        - dimensions : String
        + getPrice() double
    }
    
    OnlineStore --> "*" _Product_ 
    OnlineStore --> "*" Customer 
    Customer --> "*" ShoppingCart 
    ShoppingCart --> "*" _Product_ 
    _Product_ <|-- DigitalProduct
    _Product_ <|-- PhysicalProduct
```

## Notes:
- Digital products have no additional costs
- Physical products have shipping costs: 50 kr for items under 1 kg, 100 kr for items 1-5 kg, 200 kr for items over 5 kg
- Use `java.time.LocalDateTime` for order timestamps

