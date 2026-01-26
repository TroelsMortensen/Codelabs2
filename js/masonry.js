window.masonryLayout = (containerClass) => {
    const container = document.querySelector(`.${containerClass}`);
    if (!container) return;

    const boxes = Array.from(container.querySelectorAll('.CourseBox'));
    if (boxes.length === 0) return;

    // Ensure all boxes are absolutely positioned and get their natural width
    // We'll measure width first, then apply transforms
    boxes.forEach(box => {
        // Ensure box is positioned for measurement
        if (!box.style.position || box.style.position === 'static') {
            box.style.position = 'absolute';
            box.style.left = '0';
            box.style.top = '0';
        }
    });

    // Force reflow to ensure measurements are accurate
    void container.offsetHeight;

    // Calculate column width (use first box's width + gap)
    const firstBox = boxes[0];
    const gap = 16; // 1rem = 16px
    const boxWidth = firstBox.offsetWidth;
    const containerPadding = 16; // 1rem padding on container
    const containerWidth = container.offsetWidth - (containerPadding * 2);
    const columns = Math.floor((containerWidth + gap) / (boxWidth + gap));
    const actualColumns = Math.max(1, columns);

    // Initialize column heights
    const columnHeights = new Array(actualColumns).fill(0);

    // Calculate target positions for all boxes
    const targetPositions = boxes.map((box, index) => {
        // Find the shortest column
        const shortestColumnIndex = columnHeights.indexOf(Math.min(...columnHeights));
        
        // Calculate position (account for container padding)
        const left = containerPadding + (shortestColumnIndex * (boxWidth + gap));
        const top = columnHeights[shortestColumnIndex];

        // Update column height
        columnHeights[shortestColumnIndex] += box.offsetHeight + gap;

        return { left, top, width: boxWidth };
    });

    // Use requestAnimationFrame to ensure smooth animation start
    requestAnimationFrame(() => {
        boxes.forEach((box, index) => {
            const pos = targetPositions[index];
            
            // Ensure box is absolutely positioned
            box.style.position = 'absolute';
            box.style.left = '0';
            box.style.top = '0';
            box.style.width = `${pos.width}px`;
            
            // Apply transform for smooth animation
            box.style.transform = `translate(${pos.left}px, ${pos.top}px)`;
        });

        // Set container height to accommodate all boxes
        const maxHeight = Math.max(...columnHeights);
        container.style.height = `${maxHeight}px`;
    });
};

window.initializeMasonry = (containerClass) => {
    // Initial layout
    window.masonryLayout(containerClass);

    // Use ResizeObserver to recalculate when boxes resize
    const container = document.querySelector(`.${containerClass}`);
    if (!container) return;

    const resizeObserver = new ResizeObserver(entries => {
        // Debounce rapid resize events
        clearTimeout(window.masonryTimeout);
        window.masonryTimeout = setTimeout(() => {
            window.masonryLayout(containerClass);
        }, 100);
    });

    // Observe all course boxes
    const boxes = container.querySelectorAll('.CourseBox');
    boxes.forEach(box => resizeObserver.observe(box));

    // Also observe the container for window resize
    resizeObserver.observe(container);

    // Store observer for cleanup if needed
    container._masonryObserver = resizeObserver;
};
