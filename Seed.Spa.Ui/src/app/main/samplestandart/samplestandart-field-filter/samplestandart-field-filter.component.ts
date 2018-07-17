import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-samplestandart-field-filter',
    templateUrl: './samplestandart-field-filter.component.html',
    styleUrls: ['./samplestandart-field-filter.component.css']
})
export class SampleStandartFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
