DELIMITER $$
CREATE PROCEDURE `sp_ebi` (IN GETestacion VARCHAR(50), IN GETfrom datetime, IN GETto datetime)

BEGIN
CREATE TEMPORARY TABLE tmp_muestras AS(

select id_muestra, COUNT(nombre_parametro) as cantparams
from (
		SELECT           tbl_resultado_analisis.id_muestra, tbl_parametro_analisis.nombre_parametro
		FROM             tbl_parametro_analisis INNER JOIN
                         tbl_parametro_grupo ON tbl_parametro_analisis.id_parametro = tbl_parametro_grupo.id_parametro INNER JOIN
                         tbl_parametro_grupo_lista ON tbl_parametro_grupo.id_parametro_grupo_lista = tbl_parametro_grupo_lista.id_parametro_grupo_lista INNER JOIN
                         tbl_resultado_analisis ON tbl_parametro_analisis.id_parametro = tbl_resultado_analisis.id_parametro INNER JOIN
                         tbl_muestra ON tbl_resultado_analisis.id_estacion = tbl_muestra.id_estacion AND tbl_resultado_analisis.id_muestra = tbl_muestra.id_muestra INNER JOIN
                         estacion ON tbl_muestra.id_estacion = estacion.ID INNER JOIN
                         tbl_tipo_muestra ON tbl_muestra.id_tipo_muestra = tbl_tipo_muestra.id_tipo_muestra
		WHERE           (tbl_tipo_muestra.tipo_muestra <> N'Blanco')  AND (tbl_muestra.fecha_muestreo >= GETfrom AND tbl_muestra.fecha_muestreo <= GETto) AND
						(tbl_parametro_grupo_lista.nombre_grupo = 'Suma aniones' OR
                        tbl_parametro_grupo_lista.nombre_grupo = 'Suma cationes') AND (estacion.Name = GETestacion)  
	) as tb0
group by id_muestra	
having COUNT(nombre_parametro) = (SELECT        COUNT(tbl_parametro_grupo.id_parametro) AS cantparams
								FROM            tbl_parametro_grupo_lista INNER JOIN
												tbl_parametro_grupo ON tbl_parametro_grupo_lista.id_parametro_grupo_lista = tbl_parametro_grupo.id_parametro_grupo_lista
									WHERE     (nombre_grupo = 'Suma aniones' or nombre_grupo = 'Suma cationes'))
);                                    

CREATE TEMPORARY TABLE temp1 AS(                                    
SELECT					 estacion.Name as nombre, tbl_muestra.id_muestra, tbl_muestra.fecha_muestreo, tbl_parametro_analisis.nombre_parametro, tbl_parametro_unidad.unidad_medida, 
                         CASE tbl_resultado_analisis.qualifier WHEN '<' THEN (tbl_resultado_analisis.valor_resultado * 0.5) 
                         / (tbl_parametro_analisis.analito_formula_peso / tbl_parametro_analisis.carga ) 
                         ELSE tbl_resultado_analisis.valor_resultado / (tbl_parametro_analisis.analito_formula_peso / tbl_parametro_analisis.carga) END AS valor_resultado
FROM					 estacion INNER JOIN
                         tbl_muestra ON estacion.ID = tbl_muestra.id_estacion INNER JOIN
                         tbl_tipo_muestra ON tbl_muestra.id_tipo_muestra = tbl_tipo_muestra.id_tipo_muestra INNER JOIN
                         tbl_resultado_analisis ON estacion.ID = tbl_resultado_analisis.id_estacion AND tbl_muestra.id_estacion = tbl_resultado_analisis.id_estacion AND 
                         tbl_muestra.id_muestra = tbl_resultado_analisis.id_muestra INNER JOIN
                         tbl_parametro_analisis ON tbl_resultado_analisis.id_parametro = tbl_parametro_analisis.id_parametro INNER JOIN
                         tbl_parametro_unidad ON tbl_resultado_analisis.id_unidad = tbl_parametro_unidad.id_unidad INNER JOIN
                         tbl_parametro_grupo ON tbl_parametro_analisis.id_parametro = tbl_parametro_grupo.id_parametro INNER JOIN
                         tbl_parametro_grupo_lista ON tbl_parametro_grupo.id_parametro_grupo_lista = tbl_parametro_grupo_lista.id_parametro_grupo_lista
WHERE					(tbl_tipo_muestra.tipo_muestra <> 'Blanco') AND (estacion.Name = GETestacion) AND (tbl_muestra.fecha_muestreo >= GETfrom  AND tbl_muestra.fecha_muestreo <= GETto) AND
					    (tbl_parametro_grupo_lista.nombre_grupo = 'Suma aniones')   
                        );
 
 CREATE TEMPORARY TABLE temp2 AS(                                    
	SELECT     temp1.nombre,  temp1.id_muestra,	temp1.fecha_muestreo,
		SUM(
		case nombre_parametro  
		when 'Alcalinidad Total' then case unidad_medida when 'mg CaCO3/L' then valor_resultado*1.22 else valor_resultado end  
		when 'Alcalinidad Bicarbonato' then case unidad_medida when 'mg CaCO3/L' then valor_resultado*1.22 else valor_resultado end  
		when  'Nitratos como N' then valor_resultado*4.4287 else valor_resultado end) as result_calc
	FROM temp1
	group by temp1.nombre, temp1.id_muestra, temp1.fecha_muestreo	
);
 
select temp2.nombre, temp2.id_muestra, temp2.fecha_muestreo, temp2.result_calc as  AnionSum_MEquiv, t2.valor_resultado as CationSum_MEquiv,
		(t2.valor_resultado-temp2.result_calc)/(temp2.result_calc+t2.valor_resultado)*100 as EBI, -10 as 'Menos10', 10 as 'Mas10', 
		CASE WHEN (t2.valor_resultado-temp2.result_calc)/(temp2.result_calc+t2.valor_resultado)*100 > 10 THEN 'Rechazada'
		WHEN (t2.valor_resultado-temp2.result_calc)/(temp2.result_calc+t2.valor_resultado)*100 < (-10) THEN 'Rechazada'
		ELSE 'Aceptable'
		END AS quality_control
from temp2

inner join 
(	
SELECT        estacion.Name AS nombre, tbl_muestra.id_muestra, tbl_muestra.fecha_muestreo, 
                         SUM(CASE tbl_resultado_analisis.qualifier WHEN '<' THEN (tbl_resultado_analisis.valor_resultado * 0.5) 
                         / (tbl_parametro_analisis.analito_formula_peso / tbl_parametro_analisis.carga) 
                         ELSE tbl_resultado_analisis.valor_resultado / (tbl_parametro_analisis.analito_formula_peso / tbl_parametro_analisis.carga) END) AS valor_resultado
FROM            estacion INNER JOIN
                         tbl_muestra ON estacion.ID = tbl_muestra.id_estacion INNER JOIN
                         tbl_tipo_muestra ON tbl_muestra.id_tipo_muestra = tbl_tipo_muestra.id_tipo_muestra INNER JOIN
                         tbl_resultado_analisis ON tbl_muestra.id_estacion = tbl_resultado_analisis.id_estacion AND tbl_muestra.id_muestra = tbl_resultado_analisis.id_muestra INNER JOIN
                         tbl_parametro_analisis ON tbl_resultado_analisis.id_parametro = tbl_parametro_analisis.id_parametro INNER JOIN
                         tbl_parametro_unidad ON tbl_resultado_analisis.id_unidad = tbl_parametro_unidad.id_unidad INNER JOIN
                         tbl_parametro_grupo ON tbl_parametro_analisis.id_parametro = tbl_parametro_grupo.id_parametro INNER JOIN
                         tbl_parametro_grupo_lista ON tbl_parametro_grupo.id_parametro_grupo_lista = tbl_parametro_grupo_lista.id_parametro_grupo_lista
WHERE        (tbl_tipo_muestra.tipo_muestra <> 'Blanco') AND (estacion.Name = GETestacion) AND (tbl_muestra.fecha_muestreo >= GETfrom AND tbl_muestra.fecha_muestreo <= GETto) AND 
			(tbl_parametro_grupo_lista.nombre_grupo = 'Suma cationes')
GROUP BY estacion.Name, tbl_muestra.id_muestra, tbl_muestra.fecha_muestreo

	 ) as t2
on temp2.nombre=t2.nombre and temp2.id_muestra=t2.id_muestra
inner join tmp_muestras on tmp_muestras.id_muestra = temp2.id_muestra
order by temp2.fecha_muestreo;

drop table tmp_muestras;                        
drop table temp1;
drop table temp2;

#call watermanagement_db.sp_ebi('AGS', '2003-01-01', '2005-01-01');

END


