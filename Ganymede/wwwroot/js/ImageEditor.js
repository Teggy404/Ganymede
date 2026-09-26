export function attachPanZoom(container, image) {
    let scale = 1;
    let x = 0;
    let y = 0;

    //panning helper values
    let dragging = false;
    let lastX = 0;
    let lastY = 0;

    const MIN_SCALE = 0.1;
    const MAX_SCALE = 20;

    function apply() {
        image.style.transform = `translate(${x}px, ${y}px) scale(${scale})`;
    }

    //Zoom in/out
    container.addEventListener("wheel", (e) => {
        e.preventDefault();

        const rect = container.getBoundingClientRect()
        const cursorX = e.clientX - rect.left;
        const cursorY = e.clientY - rect.top;

        const factor = e.deltaY < 0 ? 1.1 : 0.9;

        const newScale = Math.min(MAX_SCALE, Math.max(MIN_SCALE, scale * factor));

        const ratio = newScale / scale;

        x = cursorX - (cursorX - x) * ratio;
        y = cursorY - (cursorY - y) * ratio;
        scale = newScale;

        apply();
    }, { passive: false });

    //Panning
    container.addEventListener("pointerdown", (e) => {
        dragging = true;
        lastX = e.clientX;
        lastY = e.clientY;

        container.setPointerCapture(e.pointerId);
    });

    container.addEventListener("pointermove", (e) => {
        if (!dragging) return;

        x += e.clientX - lastX;
        y += e.clientY - lastY;
        lastX = e.clientX;
        lastY = e.clientY;

        apply();
    });

    const stopDrag = () => { dragging = false; }
    container.addEventListener("pointerup", stopDrag);
    container.addEventListener("pointercancel", stopDrag);
}