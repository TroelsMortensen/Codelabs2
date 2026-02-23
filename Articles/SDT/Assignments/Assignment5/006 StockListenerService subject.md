# StockListenerService as a subject

The next step in your journey is to make the `StockListenerService` a subject. We do this, so the presentation layer can listen to the service for updates, and live-update the UI.

As mentioned on the first page, this particular piece of functionality may also be located elsewhere. It is up to you.

## To Subject

Make the `StockListenerService` a subject. Pick your approach. You can use the original version, or the newer PropertyChangeSupport version. Or something else.

The primary method, you added on the previous page, about updating the Stock entity, could now update listeners (i.e. presentation layer classes). At the end. When all the important work is done. Or you can define a separate method for this. It is up to you.

## Testing

More testing, you say? Yes, certainly!

You can reuse the testing code from the previous page. Now, add a "dummy"-listener to the StockListenerService, and verify it receives the updates. You can just add a print statement. This can be done very simply with a lambda expression.

```java
stockListenerService.addListener(arg -> System.out.println("Received update: " + arg));
```

Running the code again, you should now see the updates in the console.