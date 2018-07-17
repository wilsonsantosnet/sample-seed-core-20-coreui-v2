import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sampledetail-field-filter',
    templateUrl: './sampledetail-field-filter.component.html',
    styleUrls: ['./sampledetail-field-filter.component.css']
})
export class SampleDetailFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
