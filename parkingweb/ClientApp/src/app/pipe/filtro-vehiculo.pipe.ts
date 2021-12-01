import { Pipe, PipeTransform } from '@angular/core';
import { Vehiculo } from '../Parking/models/vehiculo';

@Pipe({
  name: 'filtroVehiculo'
})
export class FiltroVehiculoPipe implements PipeTransform {

  transform(vehiculo: Vehiculo[], searchText: string): any {
    if (searchText == null) return vehiculo;
    return vehiculo.filter(p =>
      p.id_vehiculo.toLowerCase()
        .indexOf(searchText.toLowerCase()) !== -1);
  }

}
