window.initializeWheel = (canvasId, sectors, diameter) => {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;
    
    const ctx = canvas.getContext('2d');
    canvas.width = diameter;
    canvas.height = diameter;
    
    const radius = diameter / 2;
    const TAU = 2 * Math.PI;
    const arc = TAU / sectors.length;
    
    // Clear canvas
    ctx.clearRect(0, 0, diameter, diameter);
    
    // Draw each sector
    sectors.forEach((sector, i) => {
        const ang = arc * i;
        ctx.save();
        
        // Draw sector arc
        ctx.beginPath();
        ctx.fillStyle = sector.color;
        ctx.moveTo(radius, radius);
        ctx.arc(radius, radius, radius, ang, ang + arc);
        ctx.lineTo(radius, radius);
        ctx.fill();
        
        // Draw label
        ctx.translate(radius, radius);
        ctx.rotate(ang + arc / 2);
        ctx.textAlign = "right";
        ctx.fillStyle = "#000000";
        // Scale font size based on canvas diameter
        const fontSize = Math.max(20, diameter / 10);
        ctx.font = `bold ${fontSize}px sans-serif`;
        ctx.fillText(sector.label, radius - (diameter * 0.03), fontSize * 0.3);
        
        ctx.restore();
    });
};

window.redrawWheel = (canvasId, sectors, diameter) => {
    window.initializeWheel(canvasId, sectors, diameter);
};

window.getCanvasSize = (containerId) => {
    const container = document.getElementById(containerId);
    if (!container) return 500; // Default fallback
    
    const width = container.offsetWidth || container.clientWidth;
    const height = container.offsetHeight || container.clientHeight;
    const size = Math.min(width, height);
    return size > 0 ? size : 500; // Ensure we return a valid size
};
