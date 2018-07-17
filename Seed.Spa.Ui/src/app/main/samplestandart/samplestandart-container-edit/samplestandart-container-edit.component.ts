//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleStandartService } from '../samplestandart.service';

@Component({
    selector: 'app-samplestandart-container-edit',
    templateUrl: './samplestandart-container-edit.component.html',
    styleUrls: ['./samplestandart-container-edit.component.css'],
})
export class SampleStandartContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleStandartService: SampleStandartService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleStandartService.initVM();
    }

    ngOnInit() {

       
    }

}
