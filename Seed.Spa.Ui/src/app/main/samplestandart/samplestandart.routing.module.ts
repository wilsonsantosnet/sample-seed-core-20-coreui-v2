import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SampleStandartComponent } from './samplestandart.component';
import { SampleStandartEditComponent } from './samplestandart-edit/samplestandart-edit.component';
import { SampleStandartDetailsComponent } from './samplestandart-details/samplestandart-details.component';
import { SampleStandartCreateComponent } from './samplestandart-create/samplestandart-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "SampleStandart" }, component: SampleStandartComponent },
            { path: 'edit/:id', data : { title : "SampleStandart" } ,component: SampleStandartEditComponent },
            { path: 'details/:id', data : { title : "SampleStandart" }, component: SampleStandartDetailsComponent },
            { path: 'create', data : { title : "SampleStandart" }, component: SampleStandartCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class SampleStandartRoutingModule {
}