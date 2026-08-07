# Exercise 12 - Online Store System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class OnlineStore {
        - storeName : String
        + OnlineStore(storeName : String)
        + getStoreName() String
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
        + getEmail() String
        + setEmail(email : String) void
        + getShippingAddress() String
        + setShippingAddress(shippingAddress : String) void
    }
    
    class _Product_ {
        - productId : int
        - name : String
        # basePrice : double
        - category : String
        - stockQuantity : int
        + Product(productId : int, name : String, basePrice : double, category : String, stockQuantity : int)
        + getProductId() int
        + getName() String
        + getBasePrice() double
        + getCategory() String
        + getStockQuantity() int
        + setStockQuantity(stockQuantity : int) void
        + getPrice()* double
        + isInStock() boolean
    }
    
    class ShoppingCart {
        - cartId : int
        - orderDate : LocalDateTime
        + ShoppingCart(cartId : int)
        + getCartId() int
        + getOrderDate() LocalDateTime
        + addProduct(product : Product, quantity : int) void
        + removeProduct(productId : int) void
        + calculateTotal() double
    }
    
    class DigitalProduct {
        - downloadLink : String
        - fileSize : double
        + DigitalProduct(productId : int, name : String, basePrice : double, category : String, stockQuantity : int, downloadLink : String, fileSize : double)
        + getDownloadLink() String
        + getFileSize() double
        + getPrice() double
    }
    
    class PhysicalProduct {
        - weight : double
        - dimensions : String
        + PhysicalProduct(productId : int, name : String, basePrice : double, category : String, stockQuantity : int, weight : double, dimensions : String)
        + getWeight() double
        + getDimensions() String
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
- `getPrice()` in `Product` is abstract (marked with *)
- Digital products: `getPrice()` returns the base price (no additional costs)
- Physical products: `getPrice()` returns base price + shipping costs
  - Shipping costs: 50 kr for items under 1 kg, 100 kr for items 1-5 kg, 200 kr for items over 5 kg
- Use `java.time.LocalDateTime` for order timestamps
- `orderDate` is automatically set to the current date/time when a ShoppingCart is created

