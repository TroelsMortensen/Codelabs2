window.initializeMermaid = () => {
    mermaid.initialize({
        startOnLoad: true,
        classDiagram: {
            methodStyle: "colon" // Use a single colon instead of double colons
        }
    });
}
window.renderMermaid = () => {
    mermaid.init(undefined, document.querySelectorAll("pre.mermaid"));
};