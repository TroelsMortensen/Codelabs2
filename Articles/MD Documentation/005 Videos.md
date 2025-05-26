# Embedded vidoes

I have two ways to embed a video:


## iframe tag

You can use an `iframe` tag to embed a video from YouTube or another video hosting service. This will allow you custom control, which is rarely needed.

You will have to specify this `iframe` like this:

```html
<iframe src="https://youtube.com/embed/6BwybLqMa34" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
```

Notice the YouTube link is special. When you copy from YouTube, the link will look different, something like this:

"https://youtu.be/6BwybLqMa34"

This link cannot be embedded. Notice the last part is the same ID of the video, so you must change the src url.

## video tag
Alternatively, you can use my custom `video` tag to embed a video.

This will then be transformed to the above iframe automatically when rendering the page.

To use the video tag, you can write it like this:

```html
<video src="https://youtu.be/6BwybLqMa34"></video>
```

Notice here, that the "incorrect" URL is okay.