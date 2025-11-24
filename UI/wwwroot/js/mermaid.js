window.initializeMermaid = () => {
    mermaid.initialize({
        startOnLoad: true,
        theme: "base",
        themeVariables: {
            primaryColor: "#ffffff", // White background for class boxes
            primaryTextColor: "#000000", // Black text color
            primaryBorderColor: "#000000", // Black border color
            background: "#ffffff" // White overall diagram background
        }
    });
}

window.renderMermaid = () => {
    const result = mermaid.init(undefined, document.querySelectorAll("pre.mermaid"));
    
    // Handle both promise and non-promise returns
    if (result && typeof result.then === 'function') {
        result.then(() => {
            setupMermaidClickHandlers();
        }).catch(() => {
            // If promise fails, still try to setup handlers after a short delay
            setTimeout(setupMermaidClickHandlers, 100);
        });
    } else {
        // If not a promise, setup handlers after a short delay to ensure rendering is complete
        setTimeout(setupMermaidClickHandlers, 100);
    }
};

window.setupMermaidClickHandlers = () => {
    // Remove existing handlers to avoid duplicates
    document.querySelectorAll("pre.mermaid").forEach(pre => {
        pre.removeEventListener("click", handleMermaidClick);
        pre.addEventListener("click", handleMermaidClick);
        pre.style.cursor = "pointer";
        pre.title = "Click to view fullscreen";
    });
};

function handleMermaidClick(event) {
    const preElement = event.currentTarget;
    const svg = preElement.querySelector("svg");
    
    if (!svg) return;
    
    // Create modal overlay
    const modal = document.createElement("div");
    modal.className = "mermaid-fullscreen-modal";
    modal.innerHTML = `
        <div class="mermaid-fullscreen-content">
            <div class="mermaid-fullscreen-diagram">
                <button class="mermaid-close-btn" aria-label="Close">&times;</button>
            </div>
        </div>
    `;
    
    // Clone the SVG for the modal
    const clonedSvg = svg.cloneNode(true);
    const diagramContainer = modal.querySelector(".mermaid-fullscreen-diagram");
    diagramContainer.appendChild(clonedSvg);
    
    // Add to body
    document.body.appendChild(modal);
    document.body.style.overflow = "hidden"; // Prevent background scrolling
    
    // Close handlers
    const closeBtn = modal.querySelector(".mermaid-close-btn");
    const closeModal = () => {
        document.body.removeChild(modal);
        document.body.style.overflow = "";
    };
    
    closeBtn.addEventListener("click", closeModal);
    modal.addEventListener("click", (e) => {
        if (e.target === modal) {
            closeModal();
        }
    });
    
    // Close on Escape key
    const escapeHandler = (e) => {
        if (e.key === "Escape") {
            closeModal();
            document.removeEventListener("keydown", escapeHandler);
        }
    };
    document.addEventListener("keydown", escapeHandler);
};