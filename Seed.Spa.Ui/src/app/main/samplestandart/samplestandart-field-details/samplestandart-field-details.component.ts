
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-samplestandart-field-details',
    templateUrl: './samplestandart-field-details.component.html',
    styleUrls: ['./samplestandart-field-details.component.css']
})
export class SampleStandartFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
