window.parsonsDrag = {
  sourceIndex: null,
  activeSlot: null,
  activeLine: null,
  onDragStart: function (event, index) {
    event.dataTransfer.setData('text/plain', index.toString());
    event.dataTransfer.effectAllowed = 'move';
    this.sourceIndex = index;
    event.currentTarget.classList.add('pp-line-dragging');
    event.currentTarget.closest('.pp-lines')?.classList.add('pp-dragging');
  },
  onLineDragOver: function (event, lineIndex) {
    event.preventDefault();
    event.dataTransfer.dropEffect = 'move';
    this.setLineHint(event.currentTarget, lineIndex);
  },
  onSlotDragOver: function (event) {
    event.preventDefault();
    event.dataTransfer.dropEffect = 'move';
    this.setSlotHint(event.currentTarget);
  },
  onLinesDragLeave: function (event) {
    if (!event.currentTarget.contains(event.relatedTarget))
      this.clearDropHints();
  },
  setSlotHint: function (slot) {
    if (!slot?.classList.contains('pp-drop-slot'))
      return;

    if (this.activeSlot === slot)
      return;

    this.clearDropHints();
    this.activeSlot = slot;
    slot.classList.add('pp-drop-slot-active');

    var prev = slot.previousElementSibling;
    var next = slot.nextElementSibling;

    if (prev?.classList.contains('pp-line') && !prev.classList.contains('pp-line-dragging'))
      prev.classList.add('pp-line-shift-up');

    if (next?.classList.contains('pp-line') && !next.classList.contains('pp-line-dragging'))
      next.classList.add('pp-line-shift-down');
  },
  setLineHint: function (line, lineIndex) {
    if (!line || line.classList.contains('pp-line-dragging'))
      return;

    if (this.activeLine === line)
      return;

    this.clearDropHints();
    this.activeLine = line;
    line.classList.add('pp-line-drop-active');

    if (lineIndex === 0)
      line.classList.add('pp-line-shift-down');
    else
      line.classList.add('pp-line-shift-up');
  },
  consumeSourceIndex: function () {
    var index = this.sourceIndex;
    this.sourceIndex = null;
    this.clearAllVisuals();
    return index;
  },
  clearVisuals: function () {
    this.clearAllVisuals();
  },
  clear: function () {
    this.sourceIndex = null;
    this.clearAllVisuals();
  },
  clearDropHints: function () {
    this.activeSlot = null;
    this.activeLine = null;
    document.querySelectorAll('.pp-drop-slot-active, .pp-line-drop-active, .pp-line-drop-before, .pp-line-drop-target, .pp-line-shift-up, .pp-line-shift-down')
      .forEach(function (el) {
        el.classList.remove('pp-drop-slot-active', 'pp-line-drop-active', 'pp-line-drop-before', 'pp-line-drop-target', 'pp-line-shift-up', 'pp-line-shift-down');
      });
  },
  clearAllVisuals: function () {
    this.clearDropHints();
    document.querySelectorAll('.pp-line-dragging, .pp-dragging')
      .forEach(function (el) {
        el.classList.remove('pp-line-dragging', 'pp-dragging');
      });
  }
};
