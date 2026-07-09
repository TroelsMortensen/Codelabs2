window.parsonsDrag = {
  sourceIndex: null,
  onDragStart: function (event, index) {
    event.dataTransfer.setData('text/plain', index.toString());
    event.dataTransfer.effectAllowed = 'move';
    this.sourceIndex = index;
  },
  onDragOver: function (event) {
    event.preventDefault();
    event.dataTransfer.dropEffect = 'move';
  },
  consumeSourceIndex: function () {
    var index = this.sourceIndex;
    this.sourceIndex = null;
    return index;
  },
  clear: function () {
    this.sourceIndex = null;
  }
};
