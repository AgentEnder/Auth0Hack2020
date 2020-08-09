import { Directive, Output, EventEmitter, HostBinding, HostListener } from '@angular/core';

@Directive({
    selector: '[appDragDrop]'
})
export class DragDropDirective {

    @Output() FileDropped = new EventEmitter<any>();

    @HostBinding('class') public classes = 'drag-default';

    // Dragover listener
    @HostListener('dragover', ['$event']) onDragOver(evt) {
        evt.preventDefault();
        evt.stopPropagation();
        this.classes = 'drag-over';
    }

    // Dragleave listener
    @HostListener('dragleave', ['$event']) public onDragLeave(evt) {
        evt.preventDefault();
        evt.stopPropagation();
        this.classes = 'drag-default';
    }

    // Drop listener
    @HostListener('drop', ['$event']) public ondrop(evt) {
        evt.preventDefault();
        evt.stopPropagation();
        this.classes = 'drag-default';
        const files = evt.dataTransfer.files;
        if (files.length > 0) {
            this.FileDropped.emit(files);
        }
    }
}
