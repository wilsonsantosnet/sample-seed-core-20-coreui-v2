//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleStandartService } from '../samplestandart.service';

@Component({
    selector: 'app-samplestandart-container-details',
    templateUrl: './samplestandart-container-details.component.html',
    styleUrls: ['./samplestandart-container-details.component.css'],
})
export class SampleStandartContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleStandartService: SampleStandartService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleStandartService.initVM();
    }

    ngOnInit() {

       
    }

}
