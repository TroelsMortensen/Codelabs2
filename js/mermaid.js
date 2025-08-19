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
    mermaid.init(undefined, document.querySelectorAll("pre.mermaid"));
};