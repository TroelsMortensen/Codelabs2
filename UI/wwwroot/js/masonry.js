window.masonryLayout = (containerClass) => {
    const container = document.querySelector(`.${containerClass}`);
    if (!container) return;

    const boxes = Array.from(container.querySelectorAll('.CourseBox'));
    if (boxes.length === 0) return;

    // Reset positions temporarily to measure natural widths
    boxes.forEach(box => {
        box.style.position = 'static';
        box.style.top = 'auto';
        box.style.left = 'auto';
    });

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

    // Position each box
    boxes.forEach((box, index) => {
        // Find the shortest column
        const shortestColumnIndex = columnHeights.indexOf(Math.min(...columnHeights));
        
        // Calculate position (account for container padding)
        const left = containerPadding + (shortestColumnIndex * (boxWidth + gap));
        const top = columnHeights[shortestColumnIndex];

        // Apply position
        box.style.position = 'absolute';
        box.style.left = `${left}px`;
        box.style.top = `${top}px`;
        box.style.width = `${boxWidth}px`;

        // Update column height
        columnHeights[shortestColumnIndex] += box.offsetHeight + gap;
    });

    // Set container height to accommodate all boxes
    const maxHeight = Math.max(...columnHeights);
    container.style.height = `${maxHeight}px`;
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
