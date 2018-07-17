//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleStandartService } from '../samplestandart.service';

@Component({
    selector: 'app-samplestandart-container-create',
    templateUrl: './samplestandart-container-create.component.html',
    styleUrls: ['./samplestandart-container-create.component.css'],
})
export class SampleStandartContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private sampleStandartService: SampleStandartService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleStandartService.initVM();
    }

    ngOnInit() {

       
    }

}
