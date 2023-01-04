<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
		<xsl:param name="Data"></xsl:param>
		<xsl:template match="/NewDataSet">
			<html>
				<body>
					<br />
					<br />
					<center>
						<h1>DANH SÁCH HÀNG</h1>
					</center>

					<br />

					<br />
					<table border="1" width="100%">
						<tr>
							<th>STT</th>
							<th>Mã Hàng</th>
							<th>Tên Hàng</th>
							<th>Đơn Vị Tính</th>
							<th>Đơn Giá</th>
							<th>Số Lượng</th>
							<th>Mã Nhà Cung Cấp</th>
						</tr>

						<xsl:for-each select="Hang">
							<xsl:if test="MaHang[.=$Data]">
								<tr>
									<td>
										<xsl:value-of select="position()"/>
									</td>
									<td>
										<xsl:value-of select="MaHang"/>
									</td>
									<td>
										<xsl:value-of select="TenHang"/>
									</td>
									<td>
										<xsl:value-of select="DonViTinh"/>
									</td>
									<td>
										<xsl:value-of select="DonGia"/>
									</td>
									<td>
										<xsl:value-of select="SoLuong"/>
									</td>
									<td>
										<xsl:value-of select="MaNCC"/>
									</td>
								</tr>
							</xsl:if>
						</xsl:for-each>
					</table>
				</body>
			</html>
    </xsl:template>
</xsl:stylesheet>
