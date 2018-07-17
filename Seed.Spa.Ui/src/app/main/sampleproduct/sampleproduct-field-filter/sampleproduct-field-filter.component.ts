import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sampleproduct-field-filter',
    templateUrl: './sampleproduct-field-filter.component.html',
    styleUrls: ['./sampleproduct-field-filter.component.css']
})
export class SampleProductFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
