import { Pipe, PipeTransform } from '@angular/core';
import { Estacionamiento } from '../Parking/models/estacionamiento';

@Pipe({
  name: 'filtroEstacionamiento'
})
export class FiltroEstacionamientoPipe implements PipeTransform {

  transform(estacionamiento: Estacionamiento[], searchText: string): any {
    if (searchText == null) return estacionamiento;
    return estacionamiento.filter(p =>
      p.idEstacionamiento.toLowerCase()
        .indexOf(searchText.toLowerCase()) !== -1);
  }

}
