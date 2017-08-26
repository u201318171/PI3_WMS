-- -----------------------------------------------------
-- Schema watermanagement_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `watermanagement_db` DEFAULT CHARACTER SET utf8 ;
USE `watermanagement_db` ;

-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_zona`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_zona` (
  `id_zona` INT(11) NOT NULL,
  `pais` VARCHAR(255) NOT NULL,
  `departamento` VARCHAR(255) NOT NULL,
  `provincia` VARCHAR(255) NULL DEFAULT NULL,
  `distrito` VARCHAR(255) NULL DEFAULT NULL,
  `zona` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_zona`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_perfil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_perfil` (
  `id_perfil` INT(11) NOT NULL,
  `nombre_perfil` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_perfil`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_usuario` (
  `id_usuario` INT(11) NOT NULL,
  `id_perfil` INT(11) NOT NULL,
  `usuario` VARCHAR(255) NULL DEFAULT NULL,
  `pssword` VARCHAR(255) NULL DEFAULT NULL,
  `identificador` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id_usuario`),
  INDEX `FK_tbl_usuario_tbl_perfil` (`id_perfil` ASC),
  CONSTRAINT `FK_tbl_usuario_tbl_perfil`
    FOREIGN KEY (`id_perfil`)
    REFERENCES `watermanagement_db`.`tbl_perfil` (`id_perfil`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_cliente` (
  `id_cliente` INT(11) NOT NULL,
  `razon_social` VARCHAR(255) NULL DEFAULT NULL,
  `ruc` VARCHAR(50) NULL DEFAULT NULL,
  `telefono` VARCHAR(255) NULL DEFAULT NULL,
  `email` VARCHAR(255) NULL DEFAULT NULL,
  `web` VARCHAR(255) NULL DEFAULT NULL,
  `nombre_contacto` VARCHAR(255) NULL DEFAULT NULL,
  `telefono_contacto` VARCHAR(255) NULL DEFAULT NULL,
  `id_usuario` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id_cliente`),
  INDEX `FK_tbl_cliente_tbl_usuario` (`id_usuario` ASC),
  CONSTRAINT `FK_tbl_cliente_tbl_usuario`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `watermanagement_db`.`tbl_usuario` (`id_usuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_proyecto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_proyecto` (
  `id_proyecto` INT(11) NOT NULL,
  `nombre_proyecto` VARCHAR(255) NULL DEFAULT NULL,
  `descripcion` VARCHAR(255) NULL DEFAULT NULL,
  `id_cliente` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id_proyecto`),
  INDEX `FK_tbl_proyecto_tbl_cliente` (`id_cliente` ASC),
  CONSTRAINT `FK_tbl_proyecto_tbl_cliente`
    FOREIGN KEY (`id_cliente`)
    REFERENCES `watermanagement_db`.`tbl_cliente` (`id_cliente`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_tipo_estacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_tipo_estacion` (
  `id_tipo_estacion` INT(11) NOT NULL,
  `tipo_estacion` VARCHAR(255) NULL DEFAULT NULL,
  `descripcion` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_tipo_estacion`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`estacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`estacion` (
  `ID` INT(11) NOT NULL,
  `id_proyecto` INT(11) NULL DEFAULT NULL,
  `Name` VARCHAR(64) NOT NULL,
  `X` FLOAT NULL DEFAULT NULL,
  `Y` FLOAT NULL DEFAULT NULL,
  `X_PSAD56` FLOAT NULL DEFAULT NULL,
  `Y_PSAD56` FLOAT NULL DEFAULT NULL,
  `X_WGS84` FLOAT NULL DEFAULT NULL,
  `Y_WGS84` FLOAT NULL DEFAULT NULL,
  `elevation` FLOAT NULL DEFAULT NULL,
  `descripcion_entorno` VARCHAR(500) NULL DEFAULT NULL,
  `comentarios` VARCHAR(1000) NULL DEFAULT NULL,
  `id_tipo_estacion` INT(11) NULL DEFAULT NULL,
  `id_zona` INT(11) NULL DEFAULT NULL,
  `Report` BIT(1) NULL DEFAULT NULL,
  `estado` BIT(1) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  INDEX `FK_tbl_estacion_tbl_tipo_estacion` (`id_tipo_estacion` ASC),
  INDEX `FK_tbl_estacion_tbl_zona` (`id_zona` ASC),
  INDEX `id_proyecto` (`id_proyecto` ASC),
  CONSTRAINT `FK_tbl_estacion_tbl_zona`
    FOREIGN KEY (`id_zona`)
    REFERENCES `watermanagement_db`.`tbl_zona` (`id_zona`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_tbl_estacion_tbl_proyecto`
    FOREIGN KEY (`id_proyecto`)
    REFERENCES `watermanagement_db`.`tbl_proyecto` (`id_proyecto`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_tbl_estacion_tbl_tipo_estacion`
    FOREIGN KEY (`id_tipo_estacion`)
    REFERENCES `watermanagement_db`.`tbl_tipo_estacion` (`id_tipo_estacion`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_analisis_requerido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_analisis_requerido` (
  `id_requerimiento` INT(11) NOT NULL,
  `nombre_parametro` VARCHAR(255) NULL DEFAULT NULL,
  `preservante` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_requerimiento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_bombeo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_bombeo` (
  `id_estacion` INT(11) NOT NULL,
  `fecha` DATETIME NOT NULL,
  `caudal_ls` FLOAT NULL DEFAULT NULL,
  `tiempo_xhora` FLOAT NULL DEFAULT NULL,
  `volumen_m3` FLOAT NULL DEFAULT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_estacion`),
  CONSTRAINT `FK__tbl_bombeo__tbl_estacion`
    FOREIGN KEY (`id_estacion`)
    REFERENCES `watermanagement_db`.`estacion` (`ID`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_laboratorio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_laboratorio` (
  `id_lab` INT(11) NOT NULL,
  `nombre_laboratorio` VARCHAR(255) NOT NULL,
  `nombre_contacto` VARCHAR(255) NULL DEFAULT NULL,
  `telefono_contacto` VARCHAR(255) NULL DEFAULT NULL,
  `web` VARCHAR(255) NULL DEFAULT NULL,
  `ruc` VARCHAR(15) NULL DEFAULT NULL,
  PRIMARY KEY (`id_lab`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_cadena_custodia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_cadena_custodia` (
  `id_cc` INT(11) NOT NULL,
  `id_lab` INT(11) NOT NULL,
  `aprobado_por` INT(11) NULL DEFAULT NULL,
  `creado_por` INT(11) NULL DEFAULT NULL,
  `referencia` VARCHAR(255) NULL DEFAULT NULL,
  `enviado_por` VARCHAR(255) NULL DEFAULT NULL,
  `fecha_envio` DATETIME NULL DEFAULT NULL,
  `recibido_por` VARCHAR(255) NULL DEFAULT NULL,
  `fecha_recepcion` DATETIME NULL DEFAULT NULL,
  `instrucciones` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_cc`),
  INDEX `FK_tbl_cadena_custodia_tbl_laboratorio` (`id_lab` ASC),
  CONSTRAINT `FK_tbl_cadena_custodia_tbl_laboratorio`
    FOREIGN KEY (`id_lab`)
    REFERENCES `watermanagement_db`.`tbl_laboratorio` (`id_lab`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_tipo_muestra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_tipo_muestra` (
  `id_tipo_muestra` INT(11) NOT NULL,
  `tipo_muestra` VARCHAR(255) NOT NULL,
  `descripcion` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_tipo_muestra`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_empleado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_empleado` (
  `id_empleado` INT(11) NOT NULL,
  `nombres` VARCHAR(255) NOT NULL,
  `apellidos` VARCHAR(255) NOT NULL,
  `telefono` VARCHAR(255) NULL DEFAULT NULL,
  `id_usuario` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id_empleado`),
  INDEX `FK_tbl_empleado_tbl_usuario` (`id_usuario` ASC),
  CONSTRAINT `FK_tbl_empleado_tbl_usuario`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `watermanagement_db`.`tbl_usuario` (`id_usuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_matriz`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_matriz` (
  `id_matriz` INT(11) NOT NULL,
  `codi` VARCHAR(255) NOT NULL,
  `descripción` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_matriz`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_quality_control`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_quality_control` (
  `id_quality_control` VARCHAR(70) NOT NULL,
  `nombre_qc` VARCHAR(255) NOT NULL,
  `descripcion_qc` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_quality_control`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_muestra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_muestra` (
  `id_estacion` INT(11) NOT NULL,
  `id_muestra` VARCHAR(70) NOT NULL,
  `id_tipo_muestra` INT(11) NULL DEFAULT NULL,
  `id_matriz` INT(11) NULL DEFAULT NULL,
  `id_quality_control` VARCHAR(70) NULL DEFAULT NULL,
  `id_tecnico_campo` INT(11) NULL DEFAULT NULL,
  `fecha_muestreo` DATETIME NULL DEFAULT NULL,
  `comentario` VARCHAR(1000) NULL DEFAULT NULL,
  PRIMARY KEY (`id_estacion`, `id_muestra`),
  INDEX `FK_tbl_muestra_tbl_empleado` (`id_tecnico_campo` ASC),
  INDEX `FK_tbl_muestra_tbl_matriz` (`id_matriz` ASC),
  INDEX `FK_tbl_muestra_tbl_quality_control` (`id_quality_control` ASC),
  INDEX `FK_tbl_muestra_tbl_tipo_muestra` (`id_tipo_muestra` ASC),
  CONSTRAINT `FK_tbl_muestra_tbl_tipo_muestra`
    FOREIGN KEY (`id_tipo_muestra`)
    REFERENCES `watermanagement_db`.`tbl_tipo_muestra` (`id_tipo_muestra`),
  CONSTRAINT `FK_tbl_muestra_tbl_empleado`
    FOREIGN KEY (`id_tecnico_campo`)
    REFERENCES `watermanagement_db`.`tbl_empleado` (`id_empleado`),
  CONSTRAINT `FK_tbl_muestra_tbl_matriz`
    FOREIGN KEY (`id_matriz`)
    REFERENCES `watermanagement_db`.`tbl_matriz` (`id_matriz`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_tbl_muestra_tbl_quality_control`
    FOREIGN KEY (`id_quality_control`)
    REFERENCES `watermanagement_db`.`tbl_quality_control` (`id_quality_control`),
  CONSTRAINT `FK__tbl_muestra__tbl_estacion`
    FOREIGN KEY (`id_estacion`)
    REFERENCES `watermanagement_db`.`estacion` (`ID`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_cadena_custodia_detalle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_cadena_custodia_detalle` (
  `id_cc` INT(11) NOT NULL,
  `id_estacion` INT(11) NOT NULL,
  `id_muestra` VARCHAR(70) NOT NULL,
  `id_requerimiento` INT(11) NOT NULL,
  `dentro_de_periodo` BIT(1) NULL DEFAULT NULL,
  `Observaciones` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_cc`, `id_requerimiento`, `id_muestra`, `id_estacion`),
  INDEX `FK_tbl_cadena_custodia_detalle_tbl_analisis_requerido` (`id_requerimiento` ASC),
  INDEX `FK_tbl_cadena_custodia_detalle_tbl_muestra` (`id_estacion` ASC, `id_muestra` ASC),
  CONSTRAINT `FK_tbl_cadena_custodia_detalle_tbl_muestra`
    FOREIGN KEY (`id_estacion` , `id_muestra`)
    REFERENCES `watermanagement_db`.`tbl_muestra` (`id_estacion` , `id_muestra`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_tbl_cadena_custodia_detalle_tbl_analisis_requerido`
    FOREIGN KEY (`id_requerimiento`)
    REFERENCES `watermanagement_db`.`tbl_analisis_requerido` (`id_requerimiento`),
  CONSTRAINT `FK_tbl_cadena_custodia_detalle_tbl_cadena_custodia`
    FOREIGN KEY (`id_cc`)
    REFERENCES `watermanagement_db`.`tbl_cadena_custodia` (`id_cc`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_parametro_unidad`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_parametro_unidad` (
  `id_unidad` INT(11) NOT NULL,
  `unidad_medida` VARCHAR(255) NOT NULL,
  `descripcion` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_unidad`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_estandar_calidad_agua`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_estandar_calidad_agua` (
  `id_eca` INT(11) NOT NULL,
  `nombre_estandar` VARCHAR(255) NULL DEFAULT NULL,
  `descripcion` VARCHAR(255) NULL DEFAULT NULL,
  `fuente` VARCHAR(255) NULL DEFAULT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  `evalua` ENUM('SI', 'NO') NULL DEFAULT NULL,
  `vigente` ENUM('SI', 'NO') NULL DEFAULT NULL,
  PRIMARY KEY (`id_eca`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_parametro_cateria`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_parametro_cateria` (
  `id_cateria` INT(11) NOT NULL,
  `cateria` VARCHAR(255) NULL DEFAULT NULL,
  `orden_cateria` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_cateria`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_parametro_analisis`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_parametro_analisis` (
  `id_parametro` INT(11) NOT NULL,
  `nombre_parametro` VARCHAR(255) NOT NULL,
  `simbologia` VARCHAR(255) NOT NULL,
  `analito_formula_peso` FLOAT NULL DEFAULT NULL,
  `carga` FLOAT NULL DEFAULT NULL,
  `id_cateria` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id_parametro`),
  INDEX `FK_tbl_parametro_analisis_tbl_parametro_cateria` (`id_cateria` ASC),
  CONSTRAINT `FK_tbl_parametro_analisis_tbl_parametro_cateria`
    FOREIGN KEY (`id_cateria`)
    REFERENCES `watermanagement_db`.`tbl_parametro_cateria` (`id_cateria`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_eca_parametro_limite`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_eca_parametro_limite` (
  `id_eca` INT(11) NOT NULL,
  `id_parametro` INT(11) NOT NULL,
  `id_unidad` INT(11) NOT NULL,
  `limite_maximo` FLOAT NULL DEFAULT NULL,
  `limite_minimo` FLOAT NULL DEFAULT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_eca`, `id_parametro`, `id_unidad`),
  INDEX `FK_tbl_eca_parametro_limite_tbl_parametro_analisis` (`id_parametro` ASC),
  INDEX `FK_tbl_eca_parametro_limite_tbl_parametro_unidad` (`id_unidad` ASC),
  CONSTRAINT `FK_tbl_eca_parametro_limite_tbl_parametro_unidad`
    FOREIGN KEY (`id_unidad`)
    REFERENCES `watermanagement_db`.`tbl_parametro_unidad` (`id_unidad`),
  CONSTRAINT `FK_tbl_eca_parametro_limite_tbl_estandar_calidad_agua`
    FOREIGN KEY (`id_eca`)
    REFERENCES `watermanagement_db`.`tbl_estandar_calidad_agua` (`id_eca`),
  CONSTRAINT `FK_tbl_eca_parametro_limite_tbl_parametro_analisis`
    FOREIGN KEY (`id_parametro`)
    REFERENCES `watermanagement_db`.`tbl_parametro_analisis` (`id_parametro`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_material`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_material` (
  `id_material` INT(11) NOT NULL,
  `nombre_material` VARCHAR(255) NOT NULL,
  `descripcion` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_material`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_meteorologia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_meteorologia` (
  `id_estacion` INT(11) NOT NULL,
  `fecha` DATETIME NOT NULL,
  `precipitacion_mm` FLOAT NULL DEFAULT NULL,
  `temperatura_C` FLOAT NULL DEFAULT NULL,
  `humedad_mm` FLOAT NULL DEFAULT NULL,
  `presion_bar` FLOAT NULL DEFAULT NULL,
  `evaporacion` FLOAT NULL DEFAULT NULL,
  `velocidad_viento` FLOAT NULL DEFAULT NULL,
  `radiacion_solar` FLOAT NULL DEFAULT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_estacion`),
  CONSTRAINT `FK__tbl_meteorologia__tbl_estacion`
    FOREIGN KEY (`id_estacion`)
    REFERENCES `watermanagement_db`.`estacion` (`ID`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_metodo_perforacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_metodo_perforacion` (
  `id_metodo_perforacion` INT(11) NOT NULL,
  `nombre_metodo` VARCHAR(255) NULL DEFAULT NULL,
  `descripcion` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_metodo_perforacion`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_nivel_agua`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_nivel_agua` (
  `id_estacion` INT(11) NOT NULL,
  `fecha` DATETIME NOT NULL,
  `cota_referencia` FLOAT NULL DEFAULT NULL,
  `profundidad_agua` FLOAT NULL DEFAULT NULL,
  `elevacion_agua` FLOAT NULL DEFAULT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_estacion`, `fecha`),
  CONSTRAINT `FK_tbl_nivel_agua_tbl_estacion`
    FOREIGN KEY (`id_estacion`)
    REFERENCES `watermanagement_db`.`estacion` (`ID`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_parametro_grupo_lista`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_parametro_grupo_lista` (
  `id_parametro_grupo_lista` INT(11) NOT NULL,
  `nombre_grupo` VARCHAR(255) NOT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_parametro_grupo_lista`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_parametro_grupo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_parametro_grupo` (
  `id_parametro_grupo_lista` INT(11) NOT NULL,
  `id_parametro` INT(11) NOT NULL,
  `comment` VARCHAR(255) NULL DEFAULT NULL,
  `orden` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_parametro_grupo_lista`, `id_parametro`),
  INDEX `FK_tbl_parametro_grupo_tbl_parametro_analisis` (`id_parametro` ASC),
  CONSTRAINT `FK_tbl_parametro_grupo_tbl_parametro_grupo_lista`
    FOREIGN KEY (`id_parametro_grupo_lista`)
    REFERENCES `watermanagement_db`.`tbl_parametro_grupo_lista` (`id_parametro_grupo_lista`),
  CONSTRAINT `FK_tbl_parametro_grupo_tbl_parametro_analisis`
    FOREIGN KEY (`id_parametro`)
    REFERENCES `watermanagement_db`.`tbl_parametro_analisis` (`id_parametro`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_perforacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_perforacion` (
  `estacion` INT(11) NOT NULL,
  `from_` FLOAT NOT NULL,
  `to_` FLOAT NOT NULL,
  `id_metodo_perforacion` INT(11) NULL DEFAULT NULL,
  `fecha_perforacion` DATETIME NULL DEFAULT NULL,
  `diametro_pulg` FLOAT NULL DEFAULT NULL,
  `inclinacion` FLOAT NULL DEFAULT NULL,
  `azimuth` FLOAT NULL DEFAULT NULL,
  `detalles` VARCHAR(255) NULL DEFAULT NULL,
  `supervisor` VARCHAR(55) NULL DEFAULT NULL,
  PRIMARY KEY (`estacion`, `from_`, `to_`),
  INDEX `FK_tbl_perforacion_tbl_metodo_perforacion_f6e8eadaf66646e189cb9d` (`id_metodo_perforacion` ASC),
  CONSTRAINT `FK_tbl_perforacion_tbl_metodo_perforacion_f6e8eadaf66646e189cb9d`
    FOREIGN KEY (`id_metodo_perforacion`)
    REFERENCES `watermanagement_db`.`tbl_metodo_perforacion` (`id_metodo_perforacion`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_tbl_perforacion_tbl_estacion`
    FOREIGN KEY (`estacion`)
    REFERENCES `watermanagement_db`.`estacion` (`ID`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_tarea`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_tarea` (
  `id_tarea` INT(11) NOT NULL,
  `nombre_tarea` VARCHAR(255) NOT NULL,
  `descripcion_tarea` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_tarea`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_plan_monitoreo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_plan_monitoreo` (
  `id_plan` INT(11) NOT NULL,
  `nombre_plan` VARCHAR(255) NOT NULL,
  `fecha_inicio` DATETIME NULL DEFAULT NULL,
  `fecha_fin` DATETIME NULL DEFAULT NULL,
  `id_tecnico_campo` INT(11) NULL DEFAULT NULL,
  `id_aprobador` INT(11) NULL DEFAULT NULL,
  `cerrado` BIT(1) NULL DEFAULT NULL,
  `observaciones` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_plan`),
  INDEX `FK_tbl_plan_monitoreo_tbl_empleado_id_aprobador` (`id_aprobador` ASC),
  INDEX `FK_tbl_plan_monitoreo_tbl_empleado_id_tecnico` (`id_tecnico_campo` ASC),
  CONSTRAINT `FK_tbl_plan_monitoreo_tbl_empleado_id_tecnico`
    FOREIGN KEY (`id_tecnico_campo`)
    REFERENCES `watermanagement_db`.`tbl_empleado` (`id_empleado`),
  CONSTRAINT `FK_tbl_plan_monitoreo_tbl_empleado_id_aprobador`
    FOREIGN KEY (`id_aprobador`)
    REFERENCES `watermanagement_db`.`tbl_empleado` (`id_empleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_plan_detalle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_plan_detalle` (
  `id_estacion` INT(11) NOT NULL,
  `id_plan` INT(11) NOT NULL,
  `id_tarea` INT(11) NOT NULL,
  `fecha_estimada` DATETIME NULL DEFAULT NULL,
  `fecha_real` DATETIME NULL DEFAULT NULL,
  `cumplido` BIT(1) NULL DEFAULT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_estacion`, `id_plan`, `id_tarea`),
  INDEX `FK_tbl_plan_detalle_tbl_plan_monitoreo` (`id_plan` ASC),
  INDEX `FK_tbl_plan_detalle_tbl_tarea` (`id_tarea` ASC),
  CONSTRAINT `FK_tbl_plan_detalle_tbl_tarea`
    FOREIGN KEY (`id_tarea`)
    REFERENCES `watermanagement_db`.`tbl_tarea` (`id_tarea`),
  CONSTRAINT `FK_tbl_plan_detalle_tbl_estacion`
    FOREIGN KEY (`id_estacion`)
    REFERENCES `watermanagement_db`.`estacion` (`ID`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_tbl_plan_detalle_tbl_plan_monitoreo`
    FOREIGN KEY (`id_plan`)
    REFERENCES `watermanagement_db`.`tbl_plan_monitoreo` (`id_plan`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_pluviometria`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_pluviometria` (
  `id_estacion` INT(11) NOT NULL,
  `fecha` DATETIME NOT NULL,
  `lluvia_mm` FLOAT NULL DEFAULT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`fecha`, `id_estacion`),
  INDEX `FK_tbl_pluviometria_tbl_estacion` (`id_estacion` ASC),
  CONSTRAINT `FK_tbl_pluviometria_tbl_estacion`
    FOREIGN KEY (`id_estacion`)
    REFERENCES `watermanagement_db`.`estacion` (`ID`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `watermanagement_db`.`tbl_resultado_analisis`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `watermanagement_db`.`tbl_resultado_analisis` (
  `id_estacion` INT(11) NOT NULL,
  `id_muestra` VARCHAR(70) NOT NULL,
  `id_parametro` INT(11) NOT NULL,
  `id_unidad` INT(11) NOT NULL,
  `metodo_analisis` VARCHAR(255) NULL DEFAULT NULL,
  `limite_deteccion` FLOAT NULL DEFAULT NULL,
  `fecha_analisis` DATETIME NULL DEFAULT NULL,
  `qualifier` VARCHAR(255) NULL DEFAULT NULL,
  `valor_resultado` FLOAT NULL DEFAULT NULL,
  `comentario` VARCHAR(255) NULL DEFAULT NULL,
  `fuente_datos` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id_estacion`, `id_muestra`, `id_parametro`, `id_unidad`),
  INDEX `FK_tbl_resultado_analisis_tbl_parametro_analisis` (`id_parametro` ASC),
  CONSTRAINT `FK_tbl_resultado_analisis_tbl_parametro_analisis`
    FOREIGN KEY (`id_parametro`)
    REFERENCES `watermanagement_db`.`tbl_parametro_analisis` (`id_parametro`),
  CONSTRAINT `FK_tbl_resultado_analisis_tbl_estacion`
    FOREIGN KEY (`id_estacion`)
    REFERENCES `watermanagement_db`.`estacion` (`ID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_tbl_resultado_analisis_tbl_muestra`
    FOREIGN KEY (`id_estacion` , `id_muestra`)
    REFERENCES `watermanagement_db`.`tbl_muestra` (`id_estacion` , `id_muestra`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

